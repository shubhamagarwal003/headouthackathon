package com.teamx.virtualtour.Helper;

import android.content.Context;

import com.teamx.virtualtour.R;

import org.rajawali3d.cardboard.RajawaliCardboardRenderer;
import org.rajawali3d.materials.Material;
import org.rajawali3d.materials.textures.ATexture;
import org.rajawali3d.materials.textures.Texture;
import org.rajawali3d.math.vector.Vector3;
import org.rajawali3d.primitives.Sphere;


public class VirtualTourImageRenderer extends RajawaliCardboardRenderer {

    public VirtualTourImageRenderer(Context context) {
        super(context);
    }

    @Override
    protected void initScene() {
        Sphere sphere = createPhotoSphereWithTexture(new Texture("photo", R.drawable.panorma));

        getCurrentScene().addChild(sphere);

        getCurrentCamera().setPosition(Vector3.ZERO);
        getCurrentCamera().setFieldOfView(75);
    }

    private static Sphere createPhotoSphereWithTexture(ATexture texture) {

        Material material = new Material();
        material.setColor(0);

        try {
            material.addTexture(texture);
        } catch (ATexture.TextureException e) {
            throw new RuntimeException(e);
        }

        Sphere sphere = new Sphere(50, 64, 32);
        sphere.setScaleX(-1);
        sphere.setMaterial(material);

        return sphere;
    }
}